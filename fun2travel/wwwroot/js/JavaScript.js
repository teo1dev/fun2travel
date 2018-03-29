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
        alert("Checked");
    }
}) 
$('#customCheck2').click(function () {
    if (this.checked) {
        alert("Checked");
    }
}) 