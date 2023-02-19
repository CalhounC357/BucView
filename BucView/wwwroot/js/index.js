const tourReqUrl = window.location.origin + "/api/tours";      // URL from which to request the tour data

requestTours();

/**
 * Sends a request to the server to obtain a collection of the tours
 * that will be added to the dropdown menu.
 */
async function requestTours () {
    const response = await fetch(tourReqUrl);
    console.log(response);

    if (response.status == 200)
    {
         updateDropdownItems(await response.json());
    }   
    // If the response was unsuccessful, signal that the tours weren't loaded properly
    else
    {
        let tourPlaceholder = {
            name: "No tours found",
            url: "."    // Link redirects to the current page
        };
        updateDropdownItems([tourPlaceholder]);
    } 
}

/**
 * Populates the tour dropdown menu with tours and links to their pages.
 * @param {} tourList A collection of tours that will be added to the menu.
 */
function updateDropdownItems(tourList) {
    const dropdownItems = document.getElementById("dropdown-items");
    dropdownItems.textContent = "";
    
    // Iterate through the list of tours, adding each one to the dropdown items element
    for (tour of tourList)
    {
        // Create a list item and set the text to the tour name
        const listItem = document.createElement("li");

        // Create an anchor tag and set the href to the tour's URL
        const tourLink = document.createElement("a");
        tourLink.setAttribute("href", tour.url);
        tourLink.textContent = tour.name;

        // Add the anchor to the list item, and the list item to the list
        listItem.appendChild(tourLink);
        dropdownItems.appendChild(listItem);
    }
}