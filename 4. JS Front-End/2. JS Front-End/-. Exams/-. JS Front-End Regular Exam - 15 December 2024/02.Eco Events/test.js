document.body.innerHTML =`
<main id="main">
            <div id="left-container">
                <div id="newApply" class="container">
                    <form class="registerEvent">
                        <h1>Register Event</h1>
                        <input type="text" placeholder="Email" id="email" />
                        <input type="text" placeholder="Event" id="event">
                        <input type="text" placeholder="Location" id="location">
                        <button type="button" id="next-btn">Next</button>
                    </form>
                </div>
            </div>

            <div id="right-container">
                <div class="container">
                    <div class="bar title-bar">
                        <h2><span>&#127810;</span>Events Preview:</h2>
                        <ul id="preview-list"></ul>
                    </div>
                </div>
                <div id="event-container">
                    <div class="container">
                        <div class="bar title-bar board">
                            <h2><span>&#127810;</span>Approved Events:</h2>
                            <ul id="event-list"></ul>
                        </div>
                    </div>
                </div>
            </div>
        </main>
        <script src="./app.js"></script>
`
result();
const applyEvent = {
        email: () => document.getElementById("email"),
        event: () => document.getElementById("event"),
        location: () => document.getElementById("location"),
        addBtn: () => document.getElementById("next-btn")
    }

  applyEvent.email().value = "john@abv.bg"
  applyEvent.event().value = "World Wetlands Day"
  applyEvent.location().value = "United Nations"

  applyEvent.addBtn().click();
expect((document.querySelector(".application>article>h4")).textContent).to.equal('john@abv.bg', 'Email is invalid.');
expect((document.querySelectorAll(".application>article>p"))[0].textContent).to.equal('Event:World Wetlands Day', 'Event is invalid.');
expect((document.querySelectorAll(".application>article>p"))[1].textContent).to.equal('Location:United Nations', 'Location is invalid');