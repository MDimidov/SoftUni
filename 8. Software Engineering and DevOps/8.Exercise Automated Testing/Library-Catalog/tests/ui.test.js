const {test, expect} = require('@playwright/test');
const url = "http://localhost:3000";

test('Verify All Books link is visible', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('#site-header > nav > section > a');

    // Get All Books link
    const allBooksLink = await page.$('a[href="/catalog"]');

    // Check if element is visible
    const isElementVisible = await allBooksLink.isVisible();

    //Verify if the element is visible
    expect(isElementVisible).toBe(true);
}) 