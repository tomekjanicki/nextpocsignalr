using System;
using System.Linq;
using NUnit.Framework;
using Shared;
using Shouldly;
using Wcf.Code;

namespace Wcf.Tests.Code
{
    public class WhiteboardV2ProxyTests
    {
        private WhiteboardV2Proxy _whiteboardV2Proxy;

        [SetUp]
        public void Setup()
        {
            WhiteboardV2Proxy.Reset();
            _whiteboardV2Proxy = new WhiteboardV2Proxy();
        }

        [Test]
        public void GetPages_ShouldHaveTwoItems()
        {
            var result = _whiteboardV2Proxy.GetPages();

            result.Count().ShouldBe(2);
        }

        [Test]
        public void GetSquares_ShouldHaveTwoItems()
        {
            var result = _whiteboardV2Proxy.GetSquares(1);

            result.Count().ShouldBe(2);
        }

        [Test]
        public void InsertSquareAndGetSquares_ShouldHaveOneMoreItem()
        {
            const int page = 1;

            var initalResult = _whiteboardV2Proxy.GetSquares(page).ToList();

            var square = new Square { Id = Guid.NewGuid(), Left = 0, Top = 50 };

            _whiteboardV2Proxy.InsertSquare(page, square);

            var result = _whiteboardV2Proxy.GetSquares(page).ToList();

            result.Count.ShouldBe(initalResult.Count + 1);

            result.FirstOrDefault(s => s.Id == square.Id).ShouldNotBeNull();
        }

        [Test]
        public void InsertSquareAndSaveChangesAndGetSquares_ShouldHaveOneMoreItem()
        {
            const int page = 1;

            var initalResult = _whiteboardV2Proxy.GetSquares(page).ToList();

            var square = new Square { Id = Guid.NewGuid(), Left = 0, Top = 50 };

            _whiteboardV2Proxy.InsertSquare(page, square);

            _whiteboardV2Proxy.SaveChanges(page);

            var result = _whiteboardV2Proxy.GetSquares(page).ToList();

            result.Count.ShouldBe(initalResult.Count + 1);

            result.FirstOrDefault(s => s.Id == square.Id).ShouldNotBeNull();
        }

        [Test]
        public void UpdateSquareAndGetSquares_ShouldHaveTheSameNumberOfItems()
        {
            const int page = 1;

            var initalResult = _whiteboardV2Proxy.GetSquares(page).ToList();

            var square = initalResult.First();

            var newLeft = square.Left*2;

            square.Left = newLeft;

            _whiteboardV2Proxy.UpdateSquare(page, square);

            var result = _whiteboardV2Proxy.GetSquares(page).ToList();

            result.Count.ShouldBe(initalResult.Count);

            result.FirstOrDefault(s => s.Id == square.Id).ShouldNotBeNull();

            result.First(s => s.Id == square.Id).Left.ShouldBe(newLeft);
        }

        [Test]
        public void UpdateSquareAndSaveChangesAndGetSquares_ShouldHaveTheSameNumberOfItems()
        {
            const int page = 1;

            var initalResult = _whiteboardV2Proxy.GetSquares(page).ToList();

            var square = initalResult.First();

            var newLeft = square.Left * 2;

            square.Left = newLeft;

            _whiteboardV2Proxy.UpdateSquare(page, square);

            _whiteboardV2Proxy.SaveChanges(page);

            var result = _whiteboardV2Proxy.GetSquares(page).ToList();

            result.Count.ShouldBe(initalResult.Count);

            result.FirstOrDefault(s => s.Id == square.Id).ShouldNotBeNull();

            result.First(s => s.Id == square.Id).Left.ShouldBe(newLeft);
        }


        [Test]
        public void DeleteSquareAndGetSquares_ShouldNotHaveDeletedItem()
        {
            const int page = 1;

            var initalResult = _whiteboardV2Proxy.GetSquares(page).ToList();

            var square = initalResult.First();

            _whiteboardV2Proxy.DeleteSquare(page, square.Id);

            var result = _whiteboardV2Proxy.GetSquares(page).ToList();

            result.Count.ShouldBe(initalResult.Count - 1);

            result.FirstOrDefault(s => s.Id == square.Id).ShouldBeNull();
        }

        [Test]
        public void DeleteSquareAndSaveChangesAndGetSquares_ShouldNotHaveDeletedItem()
        {
            const int page = 1;

            var initalResult = _whiteboardV2Proxy.GetSquares(page).ToList();

            var square = initalResult.First();

            _whiteboardV2Proxy.DeleteSquare(page, square.Id);

            _whiteboardV2Proxy.SaveChanges(page);

            var result = _whiteboardV2Proxy.GetSquares(page).ToList();

            result.Count.ShouldBe(initalResult.Count - 1);

            result.FirstOrDefault(s => s.Id == square.Id).ShouldBeNull();
        }

    }
}
