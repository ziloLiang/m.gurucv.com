require.config({

    baseUrl: "/m.gurucv.com/",

    // alias libraries paths
    paths: {
        'jquery': 'js/lib/jquery-2.1.4.min',
        'app-config': 'js/app-config',
        'angular': 'js/lib/angular/angular',
        'angular-route': 'js/lib/angular/angular-route',
        'blockUI': 'js/lib/angular/angular-block-ui',
        'angularAMD': 'js/lib/angular/angularAMD',
        'ngload': 'js/lib/ngload',
        'ajaxService': 'js/services/ajaxServices',
        'accountServices': 'js/services/accountServices',
        'messageServices': 'js/services/messageServices',
        
        'scrollDirective': 'js/directives/scrollDirective', //滚动指令
        'IScroll': 'js/lib/iscroll'
    },

    // Add angular modules that does not support AMD out of the box, put it in a shim
    shim: {
        'angular': {
          exports: 'angular'
        },
        'IScroll': {
          exports: 'IScroll'
        },
        'angularAMD': ['angular'],
        'angular-route': ['angular'],
        'blockUI': ['angular'],
        'ngload': ['angular']
    },

    // kick start application
    deps: ['app-config']
});

require(["app-config","jquery","angularAMD","scrollDirective"],function(app,$,angularAmd){
  
  app.directive("focusOn",function($timeout){
    return {
      scope: { trigger: '=focusOn' },
      link: function(scope, ele, attrs){
        scope.$watch("trigger",function(val){
          if(val === true){
            $timeout(function(){
              ele[0].focus();
            },100);
          };
        });
      }
    }
  });
  
  
  
  app.controller("HeaderController",function($scope){
    $scope.search = {
      searchFocusOn: false
    }
  });
  app.controller("SearchController",function($scope){
    
    $scope.searchFocus = function(){
      $scope.search.searchFocusOn = true;
    }
    $scope.searchCancel = function(){
      $scope.search.searchFocusOn = false;
    }
  });
  app.controller("MessageWarpper",function($scope){
    $scope.showScroller = function(){
      console.log($scope.myScroll);
    }
    $scope.upRefresh = function(obj){
      
    }
  });
  angularAmd.bootstrap(app);

});
