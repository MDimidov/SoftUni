const { test, expect } = require('@playwright/test');
test('User can add a task'), async ({ page }) => {
    await page.goto('http://127.0.0.1:5500/');
    await page.fill('#task-input', 'Test Task');
    await page.click('#add-task');

    const taskTest = await page.textContent('.task');
    expect(taskTest).toContain('Test Task');
}