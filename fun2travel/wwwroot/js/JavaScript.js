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

$('#ActivityList').on('change', function () {
    var activitySelected = $('#ActivityList').val();
    var activityPrice = 0;
    if (activitySelected === 1) {
        activityPrice = 50;
    } else if (activitySelected === "2") {
        activityPrice = 60;
    } else if (activitySelected === "3") {
        activityPrice = 10;
    } else if (activitySelected === "4") {
        activityPrice = 40;
    } else if (activitySelected === "5") {
        activityPrice = 50;
    } else if (activitySelected === "6") {
        activityPrice = 0;
    } else if (activitySelected === "7") {
        activityPrice = 10;
    } else if (activitySelected === "8") {
        activityPrice = 50;
    } else if (activitySelected === "9") {
        activityPrice = 250;
    } else if (activitySelected === "10") {
        activityPrice = 300;
    } else if (activitySelected === "11") {
        activityPrice = 0;
    } else if (activitySelected === "12") {
        activityPrice = 500;
    }

})

$('#customCheck3').click(function () {
    if (this.checked) {

        var TransportPrice = $('#TransportPrice').html();
        var noPpl = $('#NumberofPeopleRoom').val();
        var totAmount = "Total cost for transport for " + noPpl+ " people:  "+ TransportPrice * noPpl +"   € ";

        $('#staticPriceTransport').val(totAmount);

    } else {
        $('#staticPriceTransport').val("");
    }
})

$(document).ready(function () {
    var hotelCost = $('#HotelPrice').html();
    $('#TotalHotelAmount').html(hotelCost);

});
$('#NumberofPeopleRoom').on('change', function () {
    var hotelCost = $('#HotelPrice').html();
    var noPpl = $('#NumberofPeopleRoom').val();
    var totalHotelCost = hotelCost * noPpl;

    $('#TotalHotelAmount').html(totalHotelCost);
})

//$('#NumberofPeopleRoom').on('load', function () {
//    var hotelCost = $('#HotelPrice').html();
//    var noPpl = $('#NumberofPeopleRoom').val();
//    var totalHotelCost = hotelCost * noPpl;

//    $('#TotalHotelAmount').html(totalHotelCost);
//})
