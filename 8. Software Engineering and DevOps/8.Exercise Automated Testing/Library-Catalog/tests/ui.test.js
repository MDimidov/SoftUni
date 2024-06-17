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
});

test('Verify Log In button is visible', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('nav.navbar');

    // Get Log In link
    const loginLink = await page.$('a[href="/login"]');

    // Check if element is visible
    const isElementVisible = await loginLink.isVisible();

    //Verify if the element is visible
    expect(isElementVisible).toBe(true);
});

test('Verify Register button is visible', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('nav.navbar');

    // Get Register link
    const registerLink = await page.$('a[href="/register"]');

    // Check if element is visible
    const isElementVisible = await registerLink.isVisible();

    //Verify if the element is visible
    expect(isElementVisible).toBe(true);
});


test('Verify Register link text', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('nav.navbar');

    // Get Register link
    const registerLink = await page.$('a[href="/register"]');

    // Get element text
    const elementText = await registerLink.textContent();

    //Verify if the element is visible
    expect(elementText).toEqual("Register");
});

test('Verify valid user can log in', async ({page}) =>{
    // Open the application
    await page.goto(url);

    // Locate page toolbar
    await page.waitForSelector('nav.navbar');

    // Get Log In link
    const loginLink = await page.$('a[href="/login"]');
    await loginLink.click();

    await page.fill('#email', 'peter@abv.bg');
    await page.fill('#password', '123456');

    // Log In with account
    const loginButton = await page.$('#login-form > fieldset > input');
    await loginButton.click();

    const logoutButton = await page.$('#logoutBtn');

    // Check if element is visible
    const isElementVisible = await logoutButton.isVisible();

    //Verify if the element is visible
    expect(isElementVisible).toBe(true);
});