$(document).ready(function () {
    Object.assign($.fn.dataTable.defaults, {
        responsive: true,
        autoWidth: true,
        scrollX: true,
        pagingType: 'full_numbers',
        lengthMenu: [
            [10, 25, 50, -1],
            [10, 25, 50, 'All']
        ],
    });

    $('#stockTable').DataTable();
    $('#myTable').DataTable();

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
                                '<tr class="group"><td colspan="' + numColumns + '">' + group + '</td></tr>'
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
        } else {
            table.order([groupColumn, 'asc']).draw();
        }
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

    var uploadImageElement = document.getElementById('uploadImage');
    if (uploadImageElement) {
        uploadImageElement.addEventListener('change', function () {
            if (this.files && this.files[0]) {
                var img = document.getElementById('image');
                img.src = URL.createObjectURL(this.files[0]);
            }
        });
    }

    setTimeout(() => {
        $(".notification").fadeOut("slow");
    }, 6000);

    updateSubcategories();
    $('#CategoryId').change(updateSubcategories);
});

function updateSubcategories() {
    var selectedCategoryId = document.getElementById('CategoryId').value;
    var subcategoryDropdown = document.getElementById('subcategoryId');
    var subcategories = subcategoryDropdown.querySelectorAll('option[data-category-id]');

    subcategoryDropdown.value = '';

    subcategories.forEach(function (option) {
        if (option.getAttribute('data-category-id') === selectedCategoryId || selectedCategoryId === '') {
            option.style.display = 'block';
        } else {
            option.style.display = 'none';
        }
    });
}