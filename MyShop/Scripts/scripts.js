//function showProduct(id) {

//    $.ajax({
//        type: "POST",
//        url: "/Product/ShowProduct",
//        data: { 'id': id },
//        dataType: "json",
//            success: function (data) {
//                $('#listview').replaceWith(data);            },  
//            error: function (data) {
//                $('#body').replaceWith(data);
//               alert('fail' + data)
//            }
//        });  
//}

    function showProduct(id)
    {
        window.location.replace("/Product/ShowProduct/" + id);
    }

    function Add() {
        window.location.replace("/Product/AddProduct/");
    }

    function UpdateTotalPrice() {
        $.ajax({
            type: 'GET',
            url: "Cart/UpdateTotal",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == "$0.00" || msg.d === "" || String.length == 0 || msg == null) {
                    //$('#purchaseButton').hide();
                    location.reload();
                    return;
                }
                $('#totalPrice').text(msg.d);
                $('#cart-total').text(msg.d);
            }
        })
    }
    function Change(el, type, pid) {
        var data = {
            'type': type,
            'pId': pid
        };
        $.ajax({
            type: 'POST',
            url: "Cart/QuanityChange",
            data: "{ 'type': " + type + ", 'pId': " + pid + "}",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                if (msg.d == 0) {
                    el.parentNode.parentNode.remove();
                    //$('#purchaseButton').hide()
                } else {
                    $(el).siblings('span')[0].innerHTML = msg.d
                }
                UpdateTotalPrice()
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                debugger;
            }
        });

    }

    