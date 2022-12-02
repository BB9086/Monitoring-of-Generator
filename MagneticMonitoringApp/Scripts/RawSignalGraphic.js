$('document').ready(function () {

        var fpath = $('#Path1___raw_signal').val();

        $.ajax({
            type: "GET",
            //URL can be changed to : /Measurements/GetData
            // or URL can be: $("#UrlEndPointName").val()
            url: $("#UrlEndPointName").val(),
            data: { filepath: fpath },
            //contentType: "application/json; charset=utf-8",
            //cache: false,
            dataType: "json",
            beforeSend: function () {
                $("#divloading").show();
            },
            success: function (response) {
                $("#divloading").hide();
                //   debugger  -- for debugging
                function getData() {
                    var arr = []
                    for (var i = 0; i < response.length; i++) {
                        arr.push([response[i].xCoordinate, response[i].yCoordinate]);
                    }
                    return arr;
                }

                var data = getData()

                Highcharts.setOptions({
                    lang: {
                        thousandsSep: ' ',
                        decimalPoint: '.',
                    }
                });

                Highcharts.chart('container', {
                   
                    chart: {
                        zoomType: 'x',
                    },

                    title: {
                        text: 'Raw Signal Chart'
                    },

                    subtitle: {
                        text: 'Magnetic Flux'
                    },

                    tooltip: {
                        valueDecimals: 2
                    },

                    xAxis: {
                        type: 'linear'
                    },

                    series: [{
                        data: data,
                        lineWidth: 0.5,
                        color: 'green',
                        name: 'Magnetic flux',
                    }]

                });

            },
            failure: function (response) {
                alert("Failure");
            },
            error: function (response) {
                alert("Error");
            }
        });
});