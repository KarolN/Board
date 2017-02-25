(function($){
    var removeListBtnSelector = ".list__remove-list-btn";

    function removeListFromUi(listId){
        var lists = $(".list");
        lists.each(function(){
            if(this.dataset.listId == listId){
                $(this).fadeOut();
            }
        });
    }

    function onRemoveListBtnClicked(event){
        var buttonElement = $(event.target);
        var listId = buttonElement.data("listId");


        var antiForgery = $.getAntiForigeryToken();
        var data = {listId: listId, __RequestVerificationToken: antiForgery};
        $.post("/lists/remove", data, function(response){
                 removeListFromUi(listId);
            });
    }

    $(function(){
        $(removeListBtnSelector).click(onRemoveListBtnClicked);
    });
})(jQuery)