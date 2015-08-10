jQuery(document).ready(function () {
    jQuery(".navigation_pages").on("click", function () {
        var pageNo = jQuery(this).attr('id').split("_")[1];
        var myUrl = "Movies"
        jQuery.ajax({
            type: "POST",
            cache: false,
            url: myUrl,
            data: { currentPage: pageNo },
            success: function(result){
                updateUI(result)
            },
            error: function(result){
                alert("Nah, futu-i!")
            }
        })
    })
})