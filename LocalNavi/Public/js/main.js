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
    
});