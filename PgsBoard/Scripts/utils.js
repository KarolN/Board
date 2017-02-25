(function($){

    function getAntiForgeryToken(){
        var antiForgery = $("#AntiForigeryToken input").val();
        return antiForgery;
        }

    $.getAntiForigeryToken = getAntiForgeryToken;

})(jQuery)