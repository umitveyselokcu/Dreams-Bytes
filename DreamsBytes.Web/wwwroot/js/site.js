// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {    
        $("a[data-Index]").on("click", function () {
           
            var productId = this.dataset.index;
            $.ajax({
                url: "/Product/AddCart",
                type: "POST",
                data: { id: productId },
                success: function (data) {
                    setTimeout(function () {
                        localStorage.setItem('CartOpen', 'true');
                        location.reload();
                    }, 1700);
                },
                error: function (error) {
                    console.log(error);
                    alert(error);
                }
            });

        }); 


    $("span[data-cartitemid]").on("click", function () {       
        $.ajax({
            url: "/Product/DeleteCartItem",
            type: "POST",
            data: {
                productId: this.dataset.productid,
                userId: this.dataset.userid },
            success: function (data) {
                setTimeout(function () {
                    location.reload();
                }, 0);
            },
            error: function (error) {
                console.log(error);
                alert(error);
            }
        });

    });
    $("#cartControl").on("click", function () {      
        if ($("#myCart").height() > 10) {
            closeCart();
        } else {
            openCart();          
        }
    });
    var openCart = function () {
        $("#myCart").css("display", "block");
        $("#myCart").css("padding-top", "100px");
        $("#cartControl").text("Sepeti Kapat");
        $("#myCart").css("max-height", "500px");
        localStorage.setItem('CartOpen', 'true');
    };
    var closeCart = function () {
        $("#myCart").css("padding-top", "0");
        $("#cartControl").text("Sepeti Aç");
        $("#myCart").css("max-height", "2px");
        localStorage.setItem('CartOpen', 'false');
        $("#myCart").css("display", "none");
    };
    if (localStorage.getItem('CartOpen') === "true") {
        openCart();       
    } else {
        closeCart();
    }
});