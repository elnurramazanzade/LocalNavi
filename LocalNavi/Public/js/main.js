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

            $("#password").displayPasswordStrength(optionalConfig);
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

    $("#AddNewPlace").submit(function (ev) {
        ev.preventDefault();
        var form = $(this);

        var formData = {
            UserID: form.find("input[name='UserID']").val(),
            Name: form.find("input[name='Name']").val(),
            Slogan: form.find("input[name='Slogan']").val(),
            CategoryID: form.find("select[name='CategoryID']").val(),
            Phone: form.find("input[name='Phone']").val(),
            CityID: form.find("select[name='CityID']").val(),
            Address: form.find("input[name='Address']").val(),
            Website: form.find("input[name='Website']").val(),
            Desc: form.find("textarea[name='Desc']").val(),
        }

        $.ajax({
            url: form.attr("action"),
            type: form.attr("method"),
            dataType: "json",
            data: formData,
            success: function (response) {
                console.log(response);
            }
        })

    });

});