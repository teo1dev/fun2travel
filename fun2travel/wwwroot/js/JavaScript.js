//import { win32 } from "path";

var activityPrice = 0;
var activityRentPrice = 0;
var totalHotelCost = 0;
var noPplAct = 0;
var noPplRoom = $('#NumberofPeopleRoom').val();
var hotelCost = $('#HotelPrice').html();
var difference = 0;
var totalHotelCost = 0;
//var TransportPrice = $('#TransportPrice').html();
var TransportPrice = 0;
var totActCost = 0;

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
    noPplAct = $('#NumberofPeopleActivity').val();

    if ($('#customCheck1').is(':checked')) {
        totActCost = (activityPrice * noPplAct) + (activityRentPrice * noPplAct);
    }
    totActCost = (activityPrice * noPplAct);

    UpdateSummary();
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
    noPplAct = $('#NumberofPeopleActivity').val();
    if ($('#customCheck1').is(':checked')) {
        totActCost = (activityPrice * noPplAct) + (activityRentPrice * noPplAct);
    }
    totActCost = activityPrice * noPplAct;

    UpdateSummary();
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
    noPplAct = $('#NumberofPeopleActivity').val();
    var totActCost = (activityPrice * noPplAct);
    UpdateSummary();
}
//DONE
$('#customCheck1').click(function () {
    if (this.checked) {
        noPplAct = $('#NumberofPeopleActivity').val();
        totActCost = activityPrice * noPplAct + activityRentPrice * noPplAct;


    } else {
        totActCost = activityPrice * noPplAct;

    }
    UpdateSummary();
})
// DONE
$('#customCheck3').click(function () {
    if (this.checked) {

        TransportPrice = $('#TransportPrice').html();
        TransportPrice = parseInt(TransportPrice);
        noPplRoom = $('#NumberofPeopleRoom').val();
        TransportPrice = TransportPrice * noPplRoom;


    } else {
        TransportPrice = 0;

    }
    UpdateSummary();
})

$('#NumberofPeopleActivity').on('change', function () {
    noPplAct = $('#NumberofPeopleActivity').val();
    if ($('#customCheck1').is(':checked')) {
        totActCost = (activityPrice * noPplAct) + (activityRentPrice * noPplAct);
    }
    totActCost = activityPrice * noPplAct;

    UpdateSummary();
})
// DONE
$('#NumberofPeopleRoom').on('change', function () {
    $('#customCheck3').prop('checked', false);

    noPplRoom = $('#NumberofPeopleRoom').val();

    UpdateSummary();
})

// DONE
$(document).ready(function () {
    hotelCost = $('#HotelPrice').html();
    hotelCost = parseInt(hotelCost);

    UpdateSummary();
});
// DONE
$('#NumberofPeopleRoom').on('change', function () {
    hotelCost = $('#HotelPrice').html();
    hotelCost = parseInt(hotelCost);
    var noPpl = $('#NumberofPeopleRoom').val();
    totalHotelCost = hotelCost * noPpl;


    UpdateSummary();
})


$('#date1').change(function () {
    var end = $('#date1').val();

})
$('#date2').change(function () {
    var end = $('#date2').val();

    var v1 = document.getElementById('date1').value;
    var v2 = document.getElementById('date2').value;
    var parts1 = v1.split('-');
    var parts2 = v2.split('-');
    var date1 = new Date(parts1[0], parts1[1], parts1[2]);
    var date2 = new Date(parts2[0], parts2[1], parts2[2]);
    difference = date2 - date1;
    difference = parseInt(difference / 86400000);
    UpdateSummary();
})


$(document).ready(function () {
    $(".dropdown-item").click(function () {
        $("#partialResultView").slideToggle(300);
    });
    $(".dropdown-item").click(function () {
        $("#partialResultView").slideToggle(300);
    });
});

function UpdateSummary() {

    $('#staticPriceEquipment').val(totActCost);
    var trpCostTotal = TransportPrice;
    $('#staticPriceTransport').val(trpCostTotal);
    totalHotelCost = hotelCost * noPplRoom * difference;

    $('#staticPriceHotel').val(totalHotelCost);
    var totalAllCost = totalHotelCost + totActCost + (TransportPrice);

    $('#staticPriceAll').val(totalAllCost);
}

// Confirm-cancel delete row in admin page
function ConfirmMessage(Id) {
    var confirmText = "Are you sure you want to delete this booking?";
    var c = confirm(confirmText);
    if (c === true)
    {

        $.ajax({
            url: "/Bookings/DeleteBooking/"+Id,
            type: "POST",
            success: function (result) {
                location.reload()
            }

        });
    }
}