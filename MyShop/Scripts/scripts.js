function showProduct(id) 
{
    $.ajax({  
        type: "POST",  
        url: "/Product/ShowProduct",  
        data: { 'id': id }  ,
        dataType: "json",
        success: function (data) {

        },  
        error: function (data) {  
            alert('fail')
        }
    });  

}