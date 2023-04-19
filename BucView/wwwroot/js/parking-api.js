const apiUrl = "";
const submitButton = document.getElementById("form-submit");
const parkingForm = document.getElementById("parking-form");
const parkingData = document.getElementById("parking-data");
var loadingFlag = false;

// Event listener that listens for clicks on the form submit button.
// When a click is heard, an API request gets sent with current form data
// and the page gets updated when the request returns.
submitButton.addEventListener("click", async (e) => {

    if (!loadingFlag) {

        loadingFlag = true;
        addSpinner();

        // send and handle resullt of api call
    }
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

    if (response.ok) {
        // load response data into the page
    }
    else {
        // say that there was an error
    }
}

// Remove all the children from an element
function removeChildren(element) {

    while (element.firstChild) {
        element.removeChild(element.firstChild);
    }
}