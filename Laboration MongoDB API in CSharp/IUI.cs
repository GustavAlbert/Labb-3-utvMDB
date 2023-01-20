namespace Laboration_MongoDB_API_in_CSharp
{
    internal interface IUI
    {
        public string GetInput();
        public string Text(string text);
        public void Clear();
        public void Exit();
    }
}
