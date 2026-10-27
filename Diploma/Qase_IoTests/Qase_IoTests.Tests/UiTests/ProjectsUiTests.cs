using Qase_IoTests.Core.Pages;
using Qase_IoTests.Tests.BaseTests;
using Qase_IoTests.Tests.Helpers;

namespace Qase_IoTests.Tests.UiTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ProjectsUiTests : BaseUiTest
{
    [Test]
    public void OpenProjectFromList()
    {
        var projectsPage = LoginAsValidUser();
        Assert.That(projectsPage.IsOpened(), Is.True);
        projectsPage.OpenProject();
        var projectPage = new ProjectPage(Driver);
        Assert.That(projectPage.IsOpened(), Is.True);
    }
    
    [Test]
    public void CreateTestCaseFormOpens()
    {
        var projectsPage = LoginAsValidUser();
        projectsPage.OpenProject();
        var projectPage = new ProjectPage(Driver);
        projectPage.OpenCreateTestCaseForm();
        Assert.That(projectPage.IsCreateTestCaseFormVisible(), Is.True);
    }
    [Test]
    public void CanEnterTestCaseTitle()
    {
        var projectsPage = LoginAsValidUser();
        projectsPage.OpenProject();
        var projectPage = new ProjectPage(Driver);
        projectPage.OpenCreateTestCaseForm();
        const string title = "UI Automation Test Case";
        projectPage.EnterTestCaseTitle(title);
        Assert.That(projectPage.GetTestCaseTitle(), Is.EqualTo(title));
    }

    [Test]
    public async Task CreateTestCaseViaUi()
    {
        var projectsPage = LoginAsValidUser();
        projectsPage.OpenProject();
        var projectPage = new ProjectPage(Driver);
        projectPage.OpenCreateTestCaseForm();
        string title = $"UI_AutoTest_{Guid.NewGuid():N}";
        int? caseId = null;
        await TestCleanup.ExecuteWithCleanupAsync(async () =>
            {
                projectPage.EnterTestCaseTitle(title);
                projectPage.SaveTestCase();
                caseId = await FindCaseIdViaApiAsync(title);
                Assert.That(caseId, Is.Not.Null);
            }, async () =>
            {
                caseId ??= await FindCaseIdViaApiAsync(title);
                if (caseId.HasValue)
                    await DeleteCaseViaApiAsync(caseId.Value);
            }, $"test case: {title}");
    }

    [Test]
    public void CreateSuiteFormOpens()
    {
        var projectPage = LoginAsValidUser()
            .OpenProject()
            .OpenCreateSuiteForm();
        Assert.That(projectPage.IsCreateSuiteFormVisible(), Is.True);
    }
    
    [TestCase("Smoke Suite")]
    [TestCase("Regression & API")]
    [TestCase("Проверка авторизации")]
    public void CanEnterSuiteTitle(string title)
    {
        var projectPage = LoginAsValidUser()
            .OpenProject()
            .OpenCreateSuiteForm()
            .EnterSuiteTitle(title);
        Assert.That(projectPage.GetSuiteTitle(), Is.EqualTo(title));
    }
    
    [Test]
    public async Task CreateSuiteViaUi()
    {
        string title = $"UI_AutoSuite_{Guid.NewGuid():N}";
        int? suiteId = null;
        await TestCleanup.ExecuteWithCleanupAsync(async () =>
            {
                LoginAsValidUser().OpenProject().OpenCreateSuiteForm().EnterSuiteTitle(title).SaveSuite();
                suiteId = await FindSuiteIdViaApiAsync(title);
                Assert.That(suiteId, Is.Not.Null);
            }, async () =>
            {
                suiteId ??= await FindSuiteIdViaApiAsync(title);
                if (suiteId.HasValue)
                    await DeleteSuiteViaApiAsync(suiteId.Value);
            }, $"test suite: {title}");
    }
    
    [Test]
    public void CannotCreateSuiteWithoutTitle()
    {
        var projectPage = LoginAsValidUser()
            .OpenProject()
            .OpenCreateSuiteForm()
            .EnterSuiteTitle("")
            .SaveSuite();
        Assert.That(projectPage.IsSuiteTitleInvalid(), Is.True);
        Assert.That(projectPage.IsCreateSuiteFormVisible(), Is.True);
    }
    
    [Test]
    public async Task SuiteCreatedViaApiIsVisibleInUi()
    {
        string title = $"API_UI_Suite_{Guid.NewGuid():N}";
        int? suiteId = null;
        await TestCleanup.ExecuteWithCleanupAsync(async () =>
            {
                suiteId = await CreateSuiteViaApiAsync(title);
                var projectPage = LoginAsValidUser().OpenProject();
                Assert.That(projectPage.IsSuiteVisible(title), Is.True);
            }, async () =>
            {
                if (suiteId.HasValue)
                    await DeleteSuiteViaApiAsync(suiteId.Value);
            }, $"test suite: {title}");
    }
}