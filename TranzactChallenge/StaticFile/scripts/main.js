$(document).ready(function () {
    let dropdown = $('#ddlState');

    dropdown.empty();

    const url = './data/states.json';

    $.getJSON(url, function (data) {
        $.each(data, function (key, entry) {
            dropdown.append($('<option></option>').attr('value', entry.abbreviation).text(entry.name));
        })
    });

    $(".requestParameter").on('change', function () { validateBeforeRequest();});
});

function changeDate() {
    let birthday = new Date($("#txtDateBirth").val());
    var ageDifMs = Date.now() - birthday.getTime();
    var ageDate = new Date(ageDifMs);
    let age = Math.abs(ageDate.getUTCFullYear() - 1970);
    $("#txtAge").val(age);
}

function calculate() {
    let premium = parseFloat($("#txtValue").val());
    if (premium > 0){
        let type = parseInt($("#ddlFrequencies").val());
        let monthly = premium / (12 / type);
        let anually = premium * type;
        $("#txtAnnual").val(anually);
        $("#txtMonthly").val(monthly);
    }
}