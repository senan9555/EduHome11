let skip = 6;
let coursesCount = $("#coursesCount").val()
$(document).on("click", "#loadMoreBtn", function () {
    $.ajax({
        url: "/Courses/LoadMoreCourses/",
        type: "get",
        data: {
            "skip":skip
        },
        success: function (response) {
            $("#myCoursesList").append(response)
            skip += 6;
            if (skip >= coursesCount) {
                $("#loadMoreBtn").remove()
            }
        }
    });
});