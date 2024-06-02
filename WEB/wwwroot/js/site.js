// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    Object.assign(DataTable.defaults, {
        responsive: true,
        autoWidth: true,
        scrollX: true,
        pagingType: 'full_numbers',
        lengthMenu: [
            [10, 25, 50, -1],
            [10, 25, 50, 'All']
        ],
    });
    var table = $('#myTable').DataTable({
        
    });
    
        $('.truncate-text').click(function () {
            var fullText = $(this).attr('data-fulltext');
            var currentText = $(this).text();
            if (currentText.endsWith('...')) {
                $(this).text(fullText);
            } else {
                $(this).text(currentText.substr(0, 40) + '...');
            }
        });
    $(document).ready(function () {
        var groupColumn = 2;
        var table = $('#myTable2').DataTable({
            columnDefs: [{ visible: false, targets: groupColumn }],
            order: [[groupColumn, 'asc']],
            drawCallback: function (settings) {
                var api = this.api();
                var rows = api.rows({ page: 'current' }).nodes();
                var last = null;

                api.column(groupColumn, { page: 'current' })
                    .data()
                    .each(function (group, i) {
                        if (last !== group) {
                            var numColumns = $(rows).eq(0).find('td').length;
                            $(rows)
                                .eq(i)
                                .before(
                                    '<tr class="group"><td colspan="' + numColumns + '">' +
                                    group +
                                    '</td></tr>'
                                );

                            last = group;
                        }
                    });
            }
             
        });
        $('#myTable2 tbody').on('click', 'tr.group', function () {
            var currentOrder = table.order()[0];
            if (currentOrder[0] === groupColumn && currentOrder[1] === 'asc') {
                table.order([groupColumn, 'desc']).draw();
            }
            else {
                table.order([groupColumn, 'asc']).draw();
            }
        });
        
       
        });

    setTimeout(() => {
        $(".notification").fadeOut("slow")
    }, 6000)
});
window.addEventListener('load', function () {
    document.getElementById('uploadImage').addEventListener('change', function () {
        if (this.files && this.files[0]) {
            var img = document.getElementById('image');
            img.src = URL.createObjectURL(this.files[0]);
        }
    });
});