/**
 * API CONNECTION
 * ------------------
 */

async function GetData(method = 'GET', url, data = null, sync = true) {
    return $.ajax({
        type: method,
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "Authorization": sessionStorage.getItem('Token')
        },
        url: "https://localhost:7029/api/" + url,
        data: JSON.stringify(data),
        async: sync,
        success: function (data) {
            return data;
        },
        error: function (x) {
            toastr.error(x.responseJSON)
        }
    });
}

/*
 * LOGIN
 * ------------------
 */
function Login(username, password) {
    if (isEmpty(username) || isEmpty(password))
        toastr.error("Butun alanlar zorunludur")
    else {
        GetData('POST', 'User/Login', { userName: username, password: password })
            .then(res => {
                toastr.success("Giris Basarili")
                sessionStorage.setItem("Token", res.token);
                setTimeout(() => { window.location.href = '/Home' }, 700)
            });
    }
}


let count = 0
var orderDetails = [];

/*
 * ADD PRODUCT
 * ------------------
 */
function AddProduct() {
    if ($('#products option:selected').val() == "-1" || isEmpty($('#piece').val()) || parseInt($('#piece').val()) < 1)
        alert('Lutfe urun seciniz ve adedi sifirdan buyuk giriniz !');
    else {
        $('#productTable').append("<tr id='" + $('#products option:selected').val() + "'><td>" + $('#products option:selected').text() + "</td><td>" + $('#piece').val() + "</td><td>" + (n(parseFloat(parseFloat($('#products option:selected').attr('price')) * parseInt($('#piece').val())).toFixed(2))) + "</td><td><button onclick='Delete(`" + $('#products option:selected').val() + "`)'>X</button></td></tr>");

        orderDetails.push({ piece: parseInt($('#piece').val()), productId: $('#products option:selected').val() });

        count++;

        $('#products option:selected').attr("disabled", "disabled");
        $('#products').val("-1");
    }

    if (count > 0)
        $('#finishOrder').removeClass('disabled');
    else
        $('#finishOrder').addClass('disabled');


}

/*
 * ORDER DELETE ROWS
 * ------------------
 */
function Delete(id) {
    $("#" + id).remove();
    count--;

    var options = $('#products option');

    options.each(function (i, x) {
        if ($(x).val() == id) {
            $(x).removeAttr("disabled")
            orderDetails.splice(orderDetails.indexOf($(x).val()), 1);
        }
    });

    $('#products').val("-1");

    if (count > 0)
        $('#finishOrder').removeClass('disabled');
    else
        $('#finishOrder').addClass('disabled');
}

/*
 * ORDER
 * ------------------
 */
function Order() {
    if (isEmpty($('#description').val()) || orderDetails.length == 0)
        alert('Siparisi tamamlamak icin lutfen urun eklemeyi ve aciklama girmeyi unutmayiniz !')
    else {
        let order = {
            description: $('#description').val(),
            orderDetails: orderDetails
        }

        GetData('POST', 'Order', order)
            .then(res => {
                alert(res);
                setTimeout(() => { location.reload() }, 750)
            });
    }
}


/*
 * PAGE LOAD
 * ------------------
 */
$(function () {
    const token = sessionStorage.getItem('Token');

    if (isEmpty(token) && window.location.pathname != '/')
        window.location.href = '/';
    else if (window.location.pathname == '/Category') {
        GetData('GET', 'Category')
            .then(res => {
                res.map(c => {
                    $('#table').append("<tr><td value='" + c.id + "'>" + c.name + "</td></tr>")
                })

            });
    }
    else if (window.location.pathname == '/Product') {
        GetData('GET', 'Product')
            .then(res => {
                res.map(c => {
                    $('#table').append("<tr><td value='" + c.id + "'>" + c.name + "</td></tr>")
                })

            });
    }
    else if (window.location.pathname == '/Order') {
        GetData('GET', 'Order')
            .then(res => {
                res.map(c => {
                    $('#table').append("<tr><td>" + new Date(c.date).toLocaleString() + "</td><td>" + c.description + "</td></tr>")

                })

            });

        GetData('GET', 'Product')
            .then(res => {
                res.map(c => {
                    $('#products').append("<option value='" + c.id + "' price='" + c.price + "'>" + c.name + "</option>")
                })

            });
    }

})

/*
 * EMPTY CONTROL
 * ------------------
 */
function isEmpty(value) {
    return (value == null || value.length === 0);
}

/*
 * GUID GENERATOR
 * ------------------
 */
function uuidv4() {
    return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}

/*
 * MONEY FORMAT
 * ------------------
 */
function n(x) { return x.toString().replace(".", ",").replace(/\B(?=(\d{3})+(?!\d))/g, "."); }