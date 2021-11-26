function pagination(tblID)
{
    $(tblID).DataTable({
        "pagingType": "simple_numbers" // "simple" option for 'Previous' and 'Next' buttons only
    });
    $('.dataTables_length').addClass('bs-select');
    $('.dataTables_length,.dataTables_info,.dataTables_paginate').show();
    $('.dataTables_length').css("margin-top", "12px");
}