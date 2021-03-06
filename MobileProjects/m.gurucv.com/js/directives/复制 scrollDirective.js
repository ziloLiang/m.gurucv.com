define(["app-config","IScroll"],function(app,IScroll){
  
  app.directive("iscroll",function(){
    return {
      link: function(scope, ele, attrs){
        var id= "#" + ele[0].id;
        var paddingTop = ele.siblings(".header")[0].offsetHeight;
        var height = $(window).height()- paddingTop;
        var scrollFn = {
          scrollRefresh: function(){
            scope.upClass = "";
            scope.upLoadText = "下拉刷新";
            scope.downClass = "";
            scope.downLoadText = "上拉刷新";
            scope.myScroll.scrollTo(0,-paddingTop,0);
            scope.myScroll.refresh();
          },
          scrollMove: function(){
            if(this.y<0 && this.y > this.maxScrollY){
              return false;
            }else if(this.y> 0 && scope.upClass == ""){
                scope.upClass = "flip";
                scope.upLoadText = "松手开始更新...";
                scope.$apply();
            }else if(this.y < 0 && scope.upClass == "flip"){
                scope.upClass = "";
                scope.upLoadText = "下拉刷新...";
                scope.$apply();
            }else if(this.y < this.maxScrollY && scope.downClass == ""){
                scope.downClass = "flip";
                scope.downLoadText = "松手开始加载数据...";
                scope.$apply();
            }else if(this.y > this.maxScrollY && scope.downClass == "flip"){
                scope.downClass = "";
                scope.downLoadText = "上拉刷新...";
                scope.$apply();
            }
            
          },
          scrollEnd: function(){
            if(this.y > -paddingTop && scope.upClass === ""){
              scope.myScroll.scrollTo(0,-paddingTop,500);
            }else if(this.y < this.maxScrollY + paddingTop && scope.downClass === ""){
                scope.myScroll.scrollTo(0,this.maxScrollY + paddingTop ,500);
            }else if(scope.upClass === "flip"){
              scope.$apply(function(){
                scope.upLoadText = "正在刷新...";
              });
              setTimeout(function(){
                scope.myScroll.scrollTo(0,-paddingTop,500);
              },1000);
//            scope.upRefresh().then(function(){
//              scrollFn.scrollRefresh();
//            },function(){
//              console.log(error);
//            });
            }else if(scope.downClass === "flip"){
              scope.$apply(function(){
                scope.downLoadText = "正在加载数据...";
              });
              setTimeout(function(){
                
              },1000);
//            scope.upRefresh().then(function(){
//              scrollFn.scrollRefresh();
//            },function(){
//              console.log(error);
//            });
            }
          }
        }
        ele.css({
          "marginTop": paddingTop,
          "height": height
        });
        scope.myScroll = new IScroll(id, { 
            preventDefault:false,
            startY: -paddingTop,
            probeType: 1
        });
          scrollFn.scrollRefresh();
        scope.myScroll.on("scroll",scrollFn.scrollMove);
        scope.myScroll.on("scrollEnd",scrollFn.scrollEnd);
      }
    }
  });
  
  
})
