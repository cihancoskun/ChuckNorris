$(document).ready(function () {

    Date.parseDate = function (input, format) {
        return moment(input, format).toDate();
    };
    Date.prototype.dateFormat = function (format) {
        return moment(this).format(format);
    };

    $("#StartDateTime").mask("00/00/0000 00:00");

    $("#StartDateTime").datetimepicker({
        format: "DD/MM/YYYY HH:mm",
        formatTime: "HH:mm",
        formatDate: "DD/MM/YYYY"
    });

    $("#EndDateTime").mask("00/00/0000 00:00");

    $("#EndDateTime").datetimepicker({
        format: "DD/MM/YYYY HH:mm",
        formatTime: "HH:mm",
        formatDate: "DD/MM/YYYY"
    });

    $.validator.addMethod("customDateTimeFormat",
                            function (value, element) {
                                if (value === "")
                                    return true;
                                return value.match(/^\d{2}\/\d{2}\/\d{2}\d{2} \d{2}:\d{2}$/);
                            },
                            "Please enter a date time in the format dd/mm/yyyy hh:mm."
                         );

    $(function () {
        $("form#frm").validate({
            rules: {
                StartDateTime: {
                    customDateTimeFormat: true
                },
                EndDateTime: {
                    customDateTimeFormat: true
                }
            }
        });
    });
});