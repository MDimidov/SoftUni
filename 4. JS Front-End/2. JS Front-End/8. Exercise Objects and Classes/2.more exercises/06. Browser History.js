function browserHistory(browser, inputArr) {
  inputArr.forEach((action) => {
    const [command, ...webSite] = action.split(" ");

    if (command === "Open") {
      browser["Open Tabs"].push(webSite);
      browser["Browser Logs"].push(action);
    } else if (action === "Clear History and Cache") {
      browser["Open Tabs"] = [];
      browser["Recently Closed"] = [];
      browser["Browser Logs"] = [];
    } else if (browser["Open Tabs"].includes(webSite.toString())) {
      const indexToDelete = browser["Open Tabs"].indexOf(webSite.toString());
      browser["Open Tabs"].splice(indexToDelete, 1);
      browser["Recently Closed"].push(webSite);
      browser["Browser Logs"].push(action);
    }
  });

  console.log(browser["Browser Name"]);
  console.log(`Open Tabs: ${browser["Open Tabs"].join(", ")}`);
  console.log(`Recently Closed: ${browser["Recently Closed"].join(", ")}`);
  console.log(`Browser Logs: ${browser["Browser Logs"].join(", ")}`);
}

browserHistory(
  {
    "Browser Name": "Mozilla Firefox",
    "Open Tabs": ["YouTube"],
    "Recently Closed": ["Gmail", "Dropbox"],
    "Browser Logs": [
      "Open Gmail",
      "Close Gmail",
      "Open Dropbox",
      "Open YouTube",
      "Close Dropbox",
    ],
  },
  ["Open Wikipedia", "Clear History and Cache", "Open Twitter"]
);
