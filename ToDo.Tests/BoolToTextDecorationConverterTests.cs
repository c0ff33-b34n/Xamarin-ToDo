using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xunit;
using ToDo;

namespace ToDo.Tests
{
    public class BoolToTextDecorationConverterTests
    {
        [Fact]
        public void Convert_returns_strikethrough_when_item_is_completed()
        {
            // Arrange
            var converter = new BoolToTextDecorationConverter();

            //Act
            var result = converter.Convert(true, null, null, null);

            //Assert
            Assert.Equal(TextDecorations.Strikethrough, (TextDecorations)result);

        }

        [Fact]
        public void Convert_returns_none_when_item_is_not_completed()
        {
            // Arrange
            var converter = new BoolToTextDecorationConverter();

            //Act
            var result = converter.Convert(false, null, null, null);

            //Assert
            Assert.Equal(TextDecorations.None, (TextDecorations)result);

        }
    }
}
