const apiUrl = "";      // CHANGE THIS TO THE API URL WHEN WE KNOW WHAT IT IS
const submitButton = document.getElementById("form-submit");
const parkingForm = document.getElementById("parking-form");
const parkingDiv = document.getElementById("parking-data");
var loadingFlag = false;

// Event listener that listens for clicks on the form submit button.
// When a click is heard, an API request gets sent with current form data
// and the page gets updated when the request returns.
submitButton.addEventListener("click", async (e) => {

    if (!loadingFlag) {

        loadingFlag = true;
        addSpinner();

        // send and handle resullt of api call
        // DISABLED UNTIL API IS AVAILABLE
        //sendRequest();

        let testData = {
            "parking_lots": [
                {
                    "lot_name": "1",
                    "available_spots": 200,
                    "closest_lat": 37.7749,
                    "closest_long": -122.4194,
                    "distance": 1,
                }
            ]
        };
        displayParkingData(testData);
    }
    // THIS IS HERE TO DEMONSTRATE FUNCTIONALITY OF THE LOADING BUTTON
    // UNTIL THE API IS AVAILABLE -- TO BE REMOVED
    else {
        clearSpinner();
        loadingFlag = false;
    }
});

// Remove content from the submit button and add a loading spinner and text
function addSpinner() {

    removeChildren(submitButton);

    let spinner = document.createElement("span");
    spinner.classList.add("spinner-border");
    spinner.classList.add("spinner-border-sm");

    let loadingText = document.createTextNode("Loading...");

    submitButton.appendChild(spinner);
    submitButton.appendChild(loadingText);
}

// Remove content from the submit button and add submit text
function clearSpinner() {

    removeChildren(submitButton);

    let submitText = document.createTextNode("Submit");
    submitButton.appendChild(submitText);
}

// Send a request to the API URL and handle the response
async function sendRequest() {

    let response = await fetch(apiUrl, {
        body: new FormData(parkingForm)
    });
    let parkingData = await response.json;

    if (response.ok) {
        // Load response data into the page
        displayParkingData(parkingData);
    }
    else {
        // Say that there was an error
        displayError();
    }
}

// Display the JSON parking data that was returned from the API
function displayParkingData(parkingData) {

    removeChildren(parkingDiv);

    let lot = parkingData.parking_lots[0];
    let text = `Closest lot: <b>Lot ${lot.lot_name}</b><br>
                Available spots: ${lot.available_spots}<br>
                Distance: ${lot.distance} mile(s)<br>
                Latitude: ${lot.closest_lat}<br>
                Longitude: ${lot.closest_long}`;

    let p = document.createElement("p");
    p.innerHTML = text;

    parkingDiv.appendChild(p);
    parkingDiv.style.display = "block";
}

// Remove all the children from an element
function removeChildren(element) {

    while (element.firstChild) {
        element.removeChild(element.firstChild);
    }
}