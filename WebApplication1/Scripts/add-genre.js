jQuery(document).ready(function () {
    jQuery("#add_genre_button").on("click", function () {
        var addedGenre = window.prompt("Add a new genre:");
        var myUrl = "PostGenre";
        if (addedGenre != null) {
            jQuery.ajax({
                type: "POST",
                url: myUrl,
                data: { newGenre: addedGenre },
                cache: false,
                success: function (result){
                    jQuery("#genres_table").append("<tr><td>" + result.data + "</td></tr>");
                    location.reload();
                },
                error: function (result) {
                    alert("An error occured!");
                }
            })
        }
    })
})