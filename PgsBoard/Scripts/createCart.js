(function($){
    var hiddenClass = "element--is-hidden";

    function addCartBtnClicked(event){
        event.stopPropagation();
        var element = $(event.target);
        element.addClass(hiddenClass);
        element.parent().next().removeClass(hiddenClass);
    }

    function onDocumentClick(event){
        $(".cart--editor").addClass(hiddenClass);
        $(".list__add-cart-btn > button").removeClass(hiddenClass);
    }

    function onCartEditorClick(event){
        event.stopPropagation();
    }

    $(function(){
        $(".list__add-cart-btn > button").click(addCartBtnClicked);
        $(".cart--editor").click(onCartEditorClick);
        $(document).click(onDocumentClick);
    });
})(jQuery);