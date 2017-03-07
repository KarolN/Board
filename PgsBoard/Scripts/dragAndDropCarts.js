(function($){
    var sortableElement = ".list__carts-container";

    function sendNewPositionToServer(cartId, newPosition){
        var data = {
            CartId: cartId,
            NewPosition: newPosition
        }
        $.post("/carts/updatePosition", data, function(){
            initializeDraggable();
        });
    }

    function sendMoveCartDataToServer(cartId, newPosition, newListId){
        var data = {
            CartId: cartId,
            NewPosition: newPosition,
            NewListId: newListId
        };
        $.post("/carts/move", data, function(){
            initializeDraggable();
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
        var item = ui.item;
        initializeDraggable();
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

    function initializeDraggable(){
        var draggableOptions = {
            connectToSortable: sortableElement,
            start: onStart,
            revert: "invalid"
        }

        $(".cart").draggable(draggableOptions);
        $( ".cart" ).draggable( "destroy" );
        $(".cart").draggable(draggableOptions);
    }

    $(function(){
        var sortableOptions = {
            axis: "y",
            stop: onDraggingStop,
            connectWith: ".list__carts-container"
        };
        $(".list__carts-container").sortable(sortableOptions);
        initializeDraggable();
    });

})(jQuery);