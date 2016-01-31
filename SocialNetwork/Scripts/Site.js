$(function () {
    $(".datepicker").datepicker({
        dateFormat: 'd M yy',
        changeMonth: true,
        changeYear: true       
    });

        $(".paging a").click(function() {
            $(".paging .current-page").attr("value",$(this).data("page"));
            $(this).closest("form").submit();
        });
    }
)