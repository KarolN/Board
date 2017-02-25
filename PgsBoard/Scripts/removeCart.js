(function($){
    var removeCartBtnSelector = ".cart__remove-cart-btn";

    function removeCartFromUi(cartId){
        var carts = $(".cart");
        carts.each(function(){
            if(this.dataset.cartId == cartId){
                $(this).fadeOut();
            }
        });
    }

    function onRemoveCartBtnClicked(event){
        var buttonElement = $(event.target);
        var cartId = buttonElement.data("cartId");

        var antiForgery = $.getAntiForigeryToken();
        var data = {cartId: cartId, __RequestVerificationToken: antiForgery};
        $.post("/carts/remove", data, function(response){
                removeCartFromUi(cartId);
        });
    }

    $(function(){
        $(removeCartBtnSelector).click(onRemoveCartBtnClicked);
    });
})(jQuery)