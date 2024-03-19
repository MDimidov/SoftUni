// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function statistics() {
    $('#statistics_btn').on('click', function (e) {
        e.preventDefault();
        e.stopPropagation();

        if ($('#statistics_box').hasClass('d-none')){
            $.get('https://localhost:7092/api/statistics', function (data) {
                $('#total_houses').text(data.totalHouses + " Houses");
                $('#total_rents').text(data.totalRent + " Rents");

                $('#statistics_box').removeClass('d-none');
                $('#statistics_btn').text('Hide statistics');
                $('#statistics_btn').removeClass('btn-primary');
                $('#statistics_btn').addClass('btn-danger');
            })
        } else {
            $('#statistics_box').addClass('d-none');    
            $('#statistics_btn').text('Show statistics');
            $('#statistics_btn').removeClass('btn-danger');
            $('#statistics_btn').addClass('btn-primary');
        }
       
    })
}