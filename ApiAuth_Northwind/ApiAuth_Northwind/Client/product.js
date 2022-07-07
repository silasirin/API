$(document).ready(function () {
    $("#getBtn").click(function () {
        var firstName = $("#firstName").val(); //val value anlaminda
        var lastName = $("#lastName").val();

        $.ajax({
            method: 'Get',
            url: '../api/products',
            headers: {
                "Authorization": "Basic " + btoa(firstName + ":" + lastName) //basic'ten sonra bir adet bosluk birakilmaz authorization'i tanimiyor!!!
            },
            success: function (data) { //buradaki data controllerdaki products
                GetProducts(data);
            },
            complete: function (data) {
                if (data.status == "401") {
                    alert("yetkiniz bulunmamaktadir.")
                }
                else if (data.status == "200") {

                    alert("giris basarili")
                }
            }
        })
    })

    function GetProducts(data) {
        data.forEach(function (val, index) {
            $("#productTable").append(`
            <tr>
            <td>${val.ID}</td>
            <td>${val.ProductName}</td>
            <td>${val.UnitPrice}</td>
            <td>${val.UnitsInStock}</td>
            </tr>
            `)
        })
    }
})