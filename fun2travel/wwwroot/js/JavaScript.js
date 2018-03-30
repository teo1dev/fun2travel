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
//$('.form_date').datetimepicker({
//    language: 'swe',
//    weekStart: 1,
//    todayBtn: 1,
//    autoclose: 1,
//    todayHighlight: 1,
//    startView: 2,
//    minView: 2,
//    forceParse: 0
//});
$('#NumberofPeopleRoom').on('change', function () {
    var hotelCost = $('#HotelPrice').html();
    var noPpl = $('#NumberofPeopleRoom').val();
    var totalHotelCost = hotelCost * noPpl;

    $('#TotalHotelAmount').html(totalHotelCost);
})
$("#datetime1").on("change", function () {
    var myDate = new Date($(this).val());
    console.log(myDate, myDate.getDate());
    var StartDay = myDate.getDate();
    var StartMonth = myDate.getMonth();
    var StartYear = myDate.getFullYear();
    console.log("Starting date " + myDate, myDate.getTime());
});
$("#datetime2").on("change", function () {
    var myDate = new Date($(this).val());
    console.log(myDate, myDate.getDate());
    var StartDay = myDate.getDate();
    var StartMonth = myDate.getMonth();
    var StartYear = myDate.getFullYear();
    console.log("Ending date" + myDate, myDate.getTime());
});
$(function () {
    $(".datepicker").datepicker();
});
