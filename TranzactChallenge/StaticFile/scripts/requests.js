function getPremium() {
    let data = {}
    $(".requestParameter").each(function () {
        let paramName = $(this).attr("parameterName");
        let paramValue = $(this).attr("type") == "number" ? parseInt($(this).val()) : $(this).val();
        data[paramName] = paramValue;
    });

    $.ajax({
        url: "/premium",
        type: "POST",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        data: JSON.stringify(data),
        async: false,
        dataType: 'json',
        success: function (response, textStatus, jqXHR) {
            $("#txtValue").val(response.premium);
            calculate();
            setControlDisabled('ddlFrequencies',false);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
            setControlDisabled('ddlFrequencies', true);
        }
    });
}