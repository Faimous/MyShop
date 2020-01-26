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

    

    