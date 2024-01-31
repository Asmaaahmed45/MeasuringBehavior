$(document).ready(function () {
    //debugger
    if (gov == "0") {
        BuildDropDown('GovernorateId', '/User/GetAllGovernorates', 'Choose');
        $('#GovernorateId').change(function () {
            BuildDropDownBasedOnSelection('GovernorateId', 'VillageId', '/User/GetVillage?GovernorateId=', 'Choose');
        });
        $('#VillageId').change(function () {
            BuildDropDownBasedOnSelection('VillageId', 'RegionId', '/User/GetRegion?VillageId=', 'Choose');
        });
    }
    else {
        BuildDropDown('GovernorateId', '/User/GetAllGovernorates', 'Choose', Governorate);
        $('#GovernorateId').change(function () {
            BuildDropDownBasedOnSelection('GovernorateId', 'VillageId', '/User/GetVillage?GovernorateId=', 'Choose', '@Model.VillageId');
        });
        $('#VillageId').change(function () {
            BuildDropDownBasedOnSelection('VillageId', 'RegionId', '/User/GetRegion?VillageId=', 'Choose', '@Model.VillageId');
        });
    }
});

function BuildDropDown(dropdownId, url, Message, selectedValue = 0) {
    $.ajax({
        type: "Get",
        url: url,
        success: function (results) {
            $("#" + dropdownId + '').empty();
            $("#" + dropdownId + '').append($('<option></option>').attr('value', 0).text(Message));
            $.each(results, function (i, result) {
                $("#" + dropdownId + '').append($('<option></option>').attr('value', result.id).text(result.name));
            });
            $("#" + dropdownId + '').val(selectedValue);
        }
    });
}

function BuildDropDownBasedOnSelection(dropdownId, subDropDownId, url, message, selectedValue = 0) {
    var subDropDown = $('#' + subDropDownId + '');
    var superDropDown = $('#' + dropdownId + '').val();
    subDropDown.empty();
    $.ajax({
        type: "Get",
        url: url + superDropDown + "",
        success: function (results) {
            subDropDown.append($('<option></option>').attr('value', 0).text(message));
            $.each(results, function (i, result) {
                subDropDown.append($('<option></option>').attr('value', result.id).text(result.name));
            });
            subDropDown.val(selectedValue);  // Fixed the parameter name here
        }
    });
}
