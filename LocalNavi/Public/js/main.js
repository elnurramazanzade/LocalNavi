$(document).ready(function () {

    $.validate({
        modules: 'location, date, security, file',
        onModulesLoaded: function () {
            var optionalConfig = {
                fontSize: '12pt',
                padding: '4px',
                bad: 'Çox zəif',
                weak: 'Zəif',
                good: 'Yaxşı',
                strong: 'Güclü'
            };

            $('input[id="password"]').displayPasswordStrength(optionalConfig);
        }

    });

    $("#CategoryID").change(function () {

        $.ajax({
            url: "addplace/servicesjson/" + $(this).val(),
            type: "get",
            dataType: "json",
            success: function (services) {
                $("#CheckboxServices").children().remove();
                var div;
                if (services.Status == 404) {
                    div = `<div class="col-md-12 responsive-wrap text-center">Xidmət növü seçin!</div>`;
                    $("#CheckboxServices").append(div);
                } else {
                    $.each(services, function (index, item) {
                        div = `<div class="col-md-4 responsive-wrap">
                                    <div class="md-checkbox">
                                        <input id="i${item.ServiceID}" type="checkbox">
                                        <label for="i${item.ServiceID}">${item.Name}</label>
                                    </div>
                                </div>`;
                        $("#CheckboxServices").append(div);
                    });
                }
            }
        });
    });
    
});