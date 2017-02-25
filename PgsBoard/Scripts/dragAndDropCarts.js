(function($){
    var sortableElement = ".list__carts-container";

    function sendNewPositionToServer(cartId, newPosition){
        var data = {
            CartId: cartId,
            NewPosition: newPosition
        }
        $.post("/carts/updatePosition", data, function(){
            $(sortableElement).sortable("enable");
            $(".cart").draggable("enable");
        });
    }

    function sendMoveCartDataToServer(cartId, newPosition, newListId){
        var data = {
            CartId: cartId,
            NewPosition: newPosition,
            NewListId: newListId
        };
        $.post("/carts/move", data, function(){
            $(sortableElement).sortable("enable");
            $(".cart").draggable("enable");
        });
    }

    function changeSortPositionOfItem(item){
        var cartId = item.data("cartId");
        var carts = item.parent().children();
        var newPosition;
        carts.each(function(index){
            if(this.dataset.cartId == cartId){
                newPosition = index;
            }
            this.dataset.cartPosition = index;
        });
        sendNewPositionToServer(cartId, newPosition);
    }

    function moveCartToOtherList(item, oldList){
        oldList.children().each(function(index){
            this.dataset.cartPosition =index;
        });

        var newPosition;
        var cartId = item.data("cartId");
        var newListId = item.parent().data("listId");
        var carts = item.parent().children();
        carts.each(function(index){
            if(this.dataset.cartId == cartId){
                newPosition = index;
            }
            this.dataset.cartPosition = index;
        });

        sendMoveCartDataToServer(cartId, newPosition, newListId);
    }

    var startList;

    function onDraggingStop(event, ui){
        $(sortableElement).sortable("disable");
        $(".cart").draggable("disable");
        var item = ui.item;
        var stopListId = item.parent().data("listId");
        if(startList == undefined || startList.data("listId") === stopListId){
            changeSortPositionOfItem(item);
        } else {
            moveCartToOtherList(item, startList);
        }
    }

    function onStart(event, ui){
        startList = ui.helper.parent();
    }

    $(function(){
        var sortableOptions = {
            axis: "y",
            stop: onDraggingStop
        };
        $(".list__carts-container").sortable(sortableOptions);

        var draggableOptions = {
                connectToSortable: sortableElement,
                start: onStart,
                revert: "invalid"
        }

        $(".cart").draggable(draggableOptions);
    });

})(jQuery);