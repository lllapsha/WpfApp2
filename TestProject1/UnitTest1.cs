using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;

[TestClass]
public class CatalogTests
{
    [TestMethod]
    public void AddTrack_ShouldAddTrackToCatalog()
    {
        // Arrange
        var catalog = new Catalog();
        var track = new Track("TestTitle", "TestAuthor");

        // Act
        catalog.AddTrack(track);

        // Assert
        CollectionAssert.Contains(catalog.AllTracks, track);
    }

    [TestMethod]
    public void RemoveTrack_ShouldRemoveTrackFromCatalog()
    {
        // Arrange
        var catalog = new Catalog();
        var track = new Track("TestTitle", "TestAuthor");
        catalog.AddTrack(track);

        // Act
        catalog.RemoveTrack(track);

        // Assert
        CollectionAssert.DoesNotContain(catalog.AllTracks, track);
    }

    [TestMethod]
    public void FilterTracks_ShouldFilterTracksBasedOnCriteriaAndSearchString()
    {
        // Arrange
        var catalog = new Catalog();
        var track1 = new Track("Song1", "Author1");
        var track2 = new Track("Song2", "Author2");
        catalog.AddTrack(track1);
        catalog.AddTrack(track2);

        // Act
        var filteredTracks = catalog.FilterTracks("Title", "Song");

        // Assert
        CollectionAssert.Contains(filteredTracks, track1);
        CollectionAssert.DoesNotContain(filteredTracks, track2);
    }
}