using IEZettaiKillApp.Core.ApplicationService;
using IEZettaiKillApp.Core.Infrastructure.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IEZettaiKillApp.Test.ApplicationService
{
    public class IEZettaiKillServiceTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        [InlineData(0)]
        public void KillIEProcesses_ShouldKillAndReturnExpectedCount(int processFindCount)
        {
            var processFinderMock = new Mock<IProcessFinder>();
            var processMock = new Mock<IIEZettaiProcess>();
            processFinderMock.Setup(x => x.FindByName(It.IsAny<string>())).Returns(Enumerable.Repeat(0, processFindCount).Select(_ => processMock.Object));

            var classUnderTest = new IEZettaiKillService
            {
                ProcessFinder = processFinderMock.Object,
                SystemSound = Mock.Of<ISystemSound>()
            };

            classUnderTest.KillIEProcesses();


            processFinderMock.Verify(x => x.FindByName(It.IsAny<string>()), Times.Once);
            processMock.Verify(x => x.Kill(), Times.Exactly(processFindCount));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(6)]
        [InlineData(0)]
        public void KillIEProcesses_ShouldPlayBeepSounds(int processFindCount)
        {
            var processFinderMock = new Mock<IProcessFinder>();
            var systemSoundMock = new Mock<ISystemSound>();
            processFinderMock.Setup(x => x.FindByName(It.IsAny<string>())).Returns(Enumerable.Repeat(0, processFindCount).Select(_ => Mock.Of<IIEZettaiProcess>()));

            var classUnderTest = new IEZettaiKillService
            {
                ProcessFinder = processFinderMock.Object,
                SystemSound = systemSoundMock.Object
            };

            classUnderTest.KillIEProcesses();


            processFinderMock.Verify(x => x.FindByName(It.IsAny<string>()), Times.Once);
            systemSoundMock.Verify(x => x.Beep(), Times.Exactly(processFindCount));
        }
    }
}
