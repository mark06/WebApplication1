function updateUI(result){
       jQuery(".movie_table_row").remove();
    for (i = 0; i < result.data.length ; i++) {
        var dateNum = parseInt(result.data[i].ReleaseDate.split("(")[1].split(")")[0]);
        var relDate = new Date(dateNum);
        var day;
        var month;
        if (relDate.getMonth() + 1 < 10) {
            month = relDate.getMonth() + 1;
            month = "0" + month;
        }
        else {
            month = relDate.getMonth() + 1;
        }
        if (relDate.getDate() < 10)
        {
            day = "0" + relDate.getDate();
        } else {
            day = relDate.getDate();
        }
        jQuery("#movies_div table").append("<tr class ='movie_table_row'><td>" + result.data[i].Title + "</td><td>" + day + "." + month + "." + relDate.getFullYear() + "</td><td>" + result.data[i].Genre + "</td><td>" + result.data[i].Price + "</td></tr>");
    }
 }
