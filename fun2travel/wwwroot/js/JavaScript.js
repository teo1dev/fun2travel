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
$('#customCheck1').click(function () {
    if (this.checked) {
        var eqRentPrice = $('#ActivityList').val();
        var noPpl = $('#NumberofPeopleActivity').val();
        var totAmount = eqRentPrice * noPpl;
        $('#staticPriceEquipment').val("Total price for" + noPpl + "persons:" + totAmount + "€");
    } else {
        $('#staticPriceEquipment').val("");
    }
})
$('#customCheck2').click(function () {
    if (this.checked) {
        $('#staticPriceFood').val("Price2");

    } else {
        $('#staticPriceFood').val("");
    }
})
$('#customCheck3').click(function () {
    if (this.checked) {

        var TransportPrice = $('#TransportPrice').html();
        var noPpl = $('#NumberofPeopleRoom').val();
        var totAmount = TransportPrice * noPpl;

        $('#staticPriceTransport').val(totAmount);

    } else {
        $('#staticPriceTransport').val("");
    }
})

$('#NumberofPeopleRoom').on('change', function () {
    var hotelCost = $('#HotelPrice').html();
    var noPpl = $('#NumberofPeopleRoom').val();
    var totalHotelCost = hotelCost * noPpl;

    $('#TotalHotelAmount').html(totalHotelCost);
})
function validate() {
    var startDate = document.getElementById('date1').value;
    if (!isValidDate(birthday)) {
        alert("you did not enter a valid startdate");
        return false;
    }
}