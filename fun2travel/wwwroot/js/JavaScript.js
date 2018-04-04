var activityPrice = 0;
var activityRentPrice = 0;

function DropDownAjaxCall(LocationName, ActivityName) {
    $.ajax({
        url: "/Home/SelectHotelandActivity",
        type: "GET",
        data: { "LocationName": LocationName, "ActivityName": ActivityName },
        success: function (result) {
            $("#partialResultView").html(result);
            $("#ResultLocation").html(LocationName);
            $("#ResultActivity").html(ActivityName);
        }
    });
}
//DONE
$('#NumberofPeopleActivity').on('change', function () {
    var noPplAct = $('#NumberofPeopleActivity').val();
    var totEqAmount = "";
    if ($('#customCheck1').is(':checked')) {
        totEqAmount = "Total cost for Activity and renting for " + noPplAct + " people:  " + activityPrice * noPplAct + activityRentPrice * noPplAct + "    € ";
    }
    totEqAmount = "Total cost for Activity for " + noPplAct + " people:  " + activityPrice * noPplAct + "    € ";

    $('#staticPriceEquipment').val(totEqAmount);
})
// DONE
$('#ActivityList').on('change', function () {

    $('#customCheck1').prop('checked', false);
    $('#staticPriceEquipment').empty()
    var activitySelected = $('#ActivityList').val();

    if (activitySelected === 1) {
        activityPrice = 50;
        activityRentPrice = 15;
    } else if (activitySelected === "2") {
        activityPrice = 60;
        activityRentPrice = 30;
    } else if (activitySelected === "3") {
        activityPrice = 10;
        activityRentPrice = 15;
    } else if (activitySelected === "4") {
        activityPrice = 40;
        activityRentPrice = 20;
    } else if (activitySelected === "5") {
        activityPrice = 50;
        activityRentPrice = 0;
    } else if (activitySelected === "6") {
        activityPrice = 0;
        activityRentPrice = 20;
    } else if (activitySelected === "7") {
        activityPrice = 10;
        activityRentPrice = 0;
    } else if (activitySelected === "8") {
        activityPrice = 50;
        activityRentPrice = 100;
    } else if (activitySelected === "9") {
        activityPrice = 250;
        activityRentPrice = 100;
    } else if (activitySelected === "10") {
        activityPrice = 300;
        activityRentPrice = 200;
    } else if (activitySelected === "11") {
        activityPrice = 0;
        activityRentPrice = 20;
    } else if (activitySelected === "12") {
        activityPrice = 500;
        activityRentPrice = 300;
    }
    var totEqAmount = "";
    var noPplAct = $('#NumberofPeopleActivity').val();
    if ($('#customCheck1').is(':checked')) {
        totEqAmount = "Total cost for Activity and renting for " + noPplAct + " people:  " + (activityPrice * noPplAct + activityRentPrice * noPplAct) + "    € ";
    }
    totEqAmount = "Total cost for Activity for " + noPplAct + " people:  " + activityPrice * noPplAct + "    € ";

    $('#staticPriceEquipment').val(totEqAmount);
})
//done
window.onload = function () {
    var activitySelected = $('#ActivityList').val();

    if (activitySelected === 1) {
        activityPrice = 50;
        activityRentPrice = 15;
    } else if (activitySelected === "2") {
        activityPrice = 60;
        activityRentPrice = 30;
    } else if (activitySelected === "3") {
        activityPrice = 10;
        activityRentPrice = 15;
    } else if (activitySelected === "4") {
        activityPrice = 40;
        activityRentPrice = 20;
    } else if (activitySelected === "5") {
        activityPrice = 50;
        activityRentPrice = 0;
    } else if (activitySelected === "6") {
        activityPrice = 0;
        activityRentPrice = 20;
    } else if (activitySelected === "7") {
        activityPrice = 10;
        activityRentPrice = 0;
    } else if (activitySelected === "8") {
        activityPrice = 50;
        activityRentPrice = 100;
    } else if (activitySelected === "9") {
        activityPrice = 250;
        activityRentPrice = 100;
    } else if (activitySelected === "10") {
        activityPrice = 300;
        activityRentPrice = 200;
    } else if (activitySelected === "11") {
        activityPrice = 0;
        activityRentPrice = 20;
    } else if (activitySelected === "12") {
        activityPrice = 500;
        activityRentPrice = 300;
    }
    var noPplAct = $('#NumberofPeopleActivity').val();
    var totEqAmount = "Total cost for Activity for " + noPplAct + " person:  " + activityPrice * noPplAct + "    € ";
    $('#staticPriceEquipment').val(totEqAmount);

}
//DONE
$('#customCheck1').click(function () {
    if (this.checked) {
        var noPplAct = $('#NumberofPeopleActivity').val();
        var totEqAmount = "Total cost for Activity and renting for " + noPplAct + " people:  " + (activityPrice * noPplAct + activityRentPrice * noPplAct) + "    € ";

        $('#staticPriceEquipment').val(totEqAmount);

    } else {
        $('#staticPriceEquipment').val("");
    }
})
// DONE
$('#customCheck3').click(function () {
    if (this.checked) {

        var TransportPrice = $('#TransportPrice').html();
        var noPpl = $('#NumberofPeopleRoom').val();
        var totAmount = "Total cost for transport for " + noPpl + " people:  " + TransportPrice * noPpl + "   € ";

        $('#staticPriceTransport').val(totAmount);

    } else {
        $('#staticPriceTransport').val("");
    }
})

$('#NumberofPeopleActivity').on('change', function () {
    var noPplAct = $('#NumberofPeopleActivity').val();
    var totEqAmount = "";
    if ($('#customCheck1').is(':checked')) {
        totEqAmount = "Total cost for Activity and renting for " + noPplAct + " people:  " + activityPrice * noPplAct + activityRentPrice * noPplAct + "    € ";
    }
    totEqAmount = "Total cost for Activity for " + noPplAct + " people:  " + activityPrice * noPplAct + "    € ";

    $('#staticPriceEquipment').val(totEqAmount);
})
// DONE
$('#NumberofPeopleRoom').on('change', function () {
    $('#customCheck3').prop('checked', false);
    $('#staticPriceTransport').val('');
})
// DONE
$(document).ready(function () {
    var hotelCost = $('#HotelPrice').html();
    $('#TotalHotelAmount').html(hotelCost);

});
// DONE
$('#NumberofPeopleRoom').on('change', function () {
    var hotelCost = $('#HotelPrice').html();
    var noPpl = $('#NumberofPeopleRoom').val();
    var totalHotelCost = hotelCost * noPpl;

    $('#TotalHotelAmount').html(totalHotelCost);
})

//$('document').ready(function () {
//    var end = $('#date1').val();

//    alert(end);
//})
$('#date1').change(function () {
    var end = $('#date1').val();

   // alert(end);
})
$('#date2').change(function () {
    var end = $('#date2').val();

    var v1 = document.getElementById('date1').value;
    var v2 = document.getElementById('date2').value;
    var parts1 = v1.split('-');
    var parts2 = v2.split('-');
    var date1 = new Date(parts1[0], parts1[1], parts1[2]);
    var date2 = new Date(parts2[0], parts2[1], parts2[2]);
    var difference = date2 - date1;
    difference = parseInt(difference / 86400000);
    alert(difference);
})
