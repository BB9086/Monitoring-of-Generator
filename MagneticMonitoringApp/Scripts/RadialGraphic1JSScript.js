
Highcharts.chart('container', {

    chart: {
        polar: true,
    },

    title: {
        text: 'Magnetic Flux Polar Chart'
    },

    subtitle: {
        text: 'Algorithm1'
    },

    pane: {
        startAngle: 0,
        endAngle: 360
    },

    xAxis: {
        tickInterval: 1,
        min: 0,
        max: 32,
        labels: {
            formatter: function () {
                let label;
                switch (this.value) {
                    case 0:
                        label = 'Pole1';
                        break;
                    case 1:
                        label = 'Pole2';
                        break;
                    case 2:
                        label = 'Pole3';
                        break;
                    case 3:
                        label = 'Pole4';
                        break;
                    case 4:
                        label = 'Pole5';
                        break;
                    case 5:
                        label = 'Pole6';
                        break;
                    case 6:
                        label = 'Pole7';
                        break;
                    case 7:
                        label = 'Pole8';
                    case 8:
                        label = 'Pole9';
                        break;
                    case 9:
                        label = 'Pole10';
                        break;
                    case 10:
                        label = 'Pole11';
                        break;
                    case 11:
                        label = 'Pole12';
                        break;
                    case 12:
                        label = 'Pole13';
                        break;
                    case 13:
                        label = 'Pole14';
                        break;
                    case 14:
                        label = 'Pole15';
                        break;
                    case 15:
                        label = 'Pole16';
                        break;
                    case 16:
                        label = 'Pole17';
                    case 17:
                        label = 'Pole18';
                        break;
                    case 18:
                        label = 'Pole19';
                        break;
                    case 19:
                        label = 'Pole20';
                        break;
                    case 20:
                        label = 'Pole21';
                        break;
                    case 21:
                        label = 'Pole22';
                        break;
                    case 22:
                        label = 'Pole23';
                        break;
                    case 23:
                        label = 'Pole24';
                        break;
                    case 24:
                        label = 'Pole25';
                    case 25:
                        label = 'Pole26';
                        break;
                    case 26:
                        label = 'Pole27';
                        break;
                    case 27:
                        label = 'Pole28';
                        break;
                    case 28:
                        label = 'Pole29';
                        break;
                    case 29:
                        label = 'Pole30';
                        break;
                    case 30:
                        label = 'Pole31';
                        break;
                    case 31:
                        label = 'Pole32';
                        break;
                }
                return label;
            }
        }
    },

    yAxis: {
        min: -10,
        max: 10,
        plotBands: {
            from: -2.5,
            to: 2.5,
            color: '#ffe4e1'
        }
    },

    plotOptions: {
        series: {
            pointStart: 0,
            pointInterval: 1,
            color: 'green'
        },
        column: {
            pointPadding: 0,
            groupPadding: 0
        }
    },

    tooltip: {
        formatter: function () {
            return 'Value: ' + '<b>' + this.y + '</b>';
        }
    },

    series: [{
        type: 'line',
        name: 'Magnetic flux',
        data:
            (function () {
                var pole1 = parseFloat(document.getElementById("resultAlgorithm1_Pole1").value);
                var pole2 = parseFloat(document.getElementById("resultAlgorithm1_Pole2").value);
                var pole3 = parseFloat(document.getElementById("resultAlgorithm1_Pole3").value);
                var pole4 = parseFloat(document.getElementById("resultAlgorithm1_Pole4").value);
                var pole5 = parseFloat(document.getElementById("resultAlgorithm1_Pole5").value);
                var pole6 = parseFloat(document.getElementById("resultAlgorithm1_Pole6").value);
                var pole7 = parseFloat(document.getElementById("resultAlgorithm1_Pole7").value);
                var pole8 = parseFloat(document.getElementById("resultAlgorithm1_Pole8").value);
                var pole9 = parseFloat(document.getElementById("resultAlgorithm1_Pole9").value);
                var pole10 = parseFloat(document.getElementById("resultAlgorithm1_Pole10").value);
                var pole11 = parseFloat(document.getElementById("resultAlgorithm1_Pole11").value);
                var pole12 = parseFloat(document.getElementById("resultAlgorithm1_Pole12").value);
                var pole13 = parseFloat(document.getElementById("resultAlgorithm1_Pole13").value);
                var pole14 = parseFloat(document.getElementById("resultAlgorithm1_Pole14").value);
                var pole15 = parseFloat(document.getElementById("resultAlgorithm1_Pole15").value);
                var pole16 = parseFloat(document.getElementById("resultAlgorithm1_Pole16").value);
                var pole17 = parseFloat(document.getElementById("resultAlgorithm1_Pole17").value);
                var pole18 = parseFloat(document.getElementById("resultAlgorithm1_Pole18").value);
                var pole19 = parseFloat(document.getElementById("resultAlgorithm1_Pole19").value);
                var pole20 = parseFloat(document.getElementById("resultAlgorithm1_Pole20").value);
                var pole21 = parseFloat(document.getElementById("resultAlgorithm1_Pole21").value);
                var pole22 = parseFloat(document.getElementById("resultAlgorithm1_Pole22").value);
                var pole23 = parseFloat(document.getElementById("resultAlgorithm1_Pole23").value);
                var pole24 = parseFloat(document.getElementById("resultAlgorithm1_Pole24").value);
                var pole25 = parseFloat(document.getElementById("resultAlgorithm1_Pole25").value);
                var pole26 = parseFloat(document.getElementById("resultAlgorithm1_Pole26").value);
                var pole27 = parseFloat(document.getElementById("resultAlgorithm1_Pole27").value);
                var pole28 = parseFloat(document.getElementById("resultAlgorithm1_Pole28").value);
                var pole29 = parseFloat(document.getElementById("resultAlgorithm1_Pole29").value);
                var pole30 = parseFloat(document.getElementById("resultAlgorithm1_Pole30").value);
                var pole31 = parseFloat(document.getElementById("resultAlgorithm1_Pole31").value);
                var pole32 = parseFloat(document.getElementById("resultAlgorithm1_Pole32").value);

                var data = [];

                //videti kako da se u for petlji dadaju elementi u niz data?
                //for (var i = 1; i < length; 32) {
                //    data.push(window["pole" + i]);
                //}

                data.push(pole1);
                data.push(pole2);
                data.push(pole3);
                data.push(pole4);
                data.push(pole5);
                data.push(pole6);
                data.push(pole7);
                data.push(pole8);
                data.push(pole9);
                data.push(pole10);
                data.push(pole11);
                data.push(pole12);
                data.push(pole13);
                data.push(pole14);
                data.push(pole15);
                data.push(pole16);
                data.push(pole17);
                data.push(pole18);
                data.push(pole19);
                data.push(pole20);
                data.push(pole21);
                data.push(pole22);
                data.push(pole23);
                data.push(pole24);
                data.push(pole25);
                data.push(pole26);
                data.push(pole27);
                data.push(pole28);
                data.push(pole29);
                data.push(pole30);
                data.push(pole31);
                data.push(pole32);

                return data;
            }())
    }]
});