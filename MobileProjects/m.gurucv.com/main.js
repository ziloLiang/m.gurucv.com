require.config({

    baseUrl: "",

    // alias libraries paths
    paths: {
        'app-config': 'js/app-config',
        'angular': 'js/lib/angular/angular',
        'angular-route': 'js/lib/angular/angular-route',
        'blockUI': 'js/lib/angular/angular-block-ui',
        'angularAMD': 'js/lib/angular/angularAMD',
        'ngload': 'js/lib/ngload',
        'ajaxService': 'js/services/ajaxServices',
        'accountServices': 'js/services/accountServices',
        'messageServices': 'js/services/messageServices'
    },

    // Add angular modules that does not support AMD out of the box, put it in a shim
    shim: {
        'angularAMD': ['angular'],
        'angular-route': ['angular'],
        'blockUI': ['angular'],
        'ngload': ['angular']
    },

    // kick start application
    deps: ['app-config']
});
