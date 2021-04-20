function validateBeforeRequest() {
    let status = true;
    $(".requestParameter").each(function () {
        let isvalid = $(this)[0].validity.valid;
        if (!isvalid) {
            status = false;
            return;
        }
    });
    if (status) {
        setControlDisabled("btnGetValue", false);
    }
    else {
        setControlDisabled("btnGetValue", true);
        setControlDisabled("ddlFrequencies", true);
    }
}

function setControlDisabled(id, status) {
    $("#" + id).prop("disabled", status);
}