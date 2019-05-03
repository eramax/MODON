/*************************************************************************************/
// -->Template Name: Bootstrap Press Admin
// -->Author: Themedesigner
// -->Email: niravjoshi87@gmail.com
// -->File: datatable_basic_init
/*************************************************************************************/

/****************************************
 *       Basic Table                   *
 ****************************************/
$('#zero_config').DataTable({
    "oLanguage": {
        "sProcessing": "جارٍ التحميل...",
        "sLengthMenu": "أظهر _MENU_ مدخلات",
        "sZeroRecords": "لم يعثر على أية سجلات",
        "sInfo": "إظهار _START_ إلى _END_ من أصل _TOTAL_ مدخل",
        "sInfoEmpty": "يعرض 0 إلى 0 من أصل 0 سجل",
        "sInfoFiltered": "(منتقاة من مجموع _MAX_ مُدخل)",
        "sInfoPostFix": "",
        "sSearch": "ابحث:",
        "sUrl": "",
        "oPaginate": {
            "sFirst": "الأول",
            "sPrevious": "السابق",
            "sNext": "التالي",
            "sLast": "الأخير"
        }
    }
});

/****************************************
 *       Default Order Table           *
 ****************************************/
$('#default_order').DataTable({
    "order": [
        [3, "desc"]
    ]
});

/****************************************
 *       Multi-column Order Table      *
 ****************************************/
$('#multi_col_order').DataTable({
    columnDefs: [{
        targets: [0],
        orderData: [0, 1]
    }, {
        targets: [1],
        orderData: [1, 0]
    }, {
        targets: [4],
        orderData: [4, 0]
    }]
});

/****************************************
 *       Complex header Table          *
 ****************************************/
$('#complex_header').DataTable();

/****************************************
 *       DOM positioning Table         *
 ****************************************/
$('#DOM_pos').DataTable({
    "dom": '<"top"i>rt<"bottom"flp><"clear">'
});

/****************************************
 *     alternative pagination Table    *
 ****************************************/
$('#alt_pagination').DataTable({
    "pagingType": "full_numbers"
});

/****************************************
 *     vertical scroll Table    *
 ****************************************/
$('#scroll_ver').DataTable({
    "scrollY": "300px",
    "scrollCollapse": true,
    "paging": false
});

/****************************************
 * vertical scroll,dynamic height Table *
 ****************************************/
$('#scroll_ver_dynamic_hei').DataTable({
    scrollY: '50vh',
    scrollCollapse: true,
    paging: false
});

/****************************************
 *     horizontal scroll Table    *
 ****************************************/
$('#scroll_hor').DataTable({
    "scrollX": true
});

/****************************************
 * vertical & horizontal scroll Table  *
 ****************************************/
$('#scroll_ver_hor').DataTable({
    "scrollY": 300,
    "scrollX": true
});

/****************************************
 * Language - Comma decimal place Table  *
 ****************************************/
$('#lang_comma_deci').DataTable({
    "language": {
        "decimal": ",",
        "thousands": "."
    }
});

/****************************************
 *         Language options Table      *
 ****************************************/
$('#lang_opt').DataTable({
    "language": {
        "lengthMenu": "Display _MENU_ records per page",
        "zeroRecords": "Nothing found - sorry",
        "info": "Showing page _PAGE_ of _PAGES_",
        "infoEmpty": "No records available",
        "infoFiltered": "(filtered from _MAX_ total records)"
    }
});