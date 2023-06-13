$(document).ready(function () {
    // Handle input change event
    $("#searchInput").on("input", function () {
        // Get the search query from the input field
        var searchQuery = $(this).val();
        $("#searchResults").show();
        $('.search-input-group').css("width", "30rem");
        // Send AJAX request to the server
        $.ajax({
            url: "/Customer/Home/Search", // Replace with your controller and action
            type: "GET",
            data: { query: searchQuery },
            dataType: "html",
            success: function (data) {
                // Display the search results
                $("#searchResults").html(data);
            },
            error: function (xhr, status, error) {
                // Handle the error (if any)
            },
        });
    });
    // Handle blur event (when search input loses focus)
    $("#searchInput").on("blur", function () {
        // Clear the search results
        if (!isHovered) {
            $("#searchResults").hide();
            $('.search-input-group').css("width", "");
        }
    });

    $("#searchResults").on("mouseenter", function () {
        isHovered = true;
    });

    $("#searchResults").on("mouseleave", function () {
        isHovered = false;
    });
});
