jQuery(document).ready(function () {
    jQuery("#search_button").on("click", function () {
        var searchString = document.getElementById("search_string").value;
        var myUrl = "Movies/SearchMovie";
        jQuery.ajax({
            type: "POST",
            url: myUrl,
            data: { searchString: searchString },
            cahce: false,
            success: function (result) {
                updateUI(result);
                jQuery(".navigation_pages").remove();
            },
            error: function () {
                alert("We encountered some shit!")
            }
        })
    });
})